
import sys
import warnings
warnings.filterwarnings("ignore")
from datetime import timedelta
import contextlib
import pandas as pd
from prophet import Prophet
from prophet.serialize import model_from_json

with contextlib.redirect_stdout(sys.__stdout__), contextlib.redirect_stderr(sys.__stderr__):
    try:
        import plotly
    except Exception:
        pass

# --- Receive arguments from C#
model_type = sys.argv[1]  # "weekly" or "monthly"
data_path = sys.argv[2]   # path to CSV data file

if model_type == "weekly":
    period_days = 7
    model_path = r"C:\Users\DJ akhi\OneDrive\Desktop\sizzlingero\sizzlingeropos(MERGED)\sizzlingeropos\sizzlingeropos\ADMIN\Sales Report\py\trained_model_weekly.json"
elif model_type == "monthly":
    period_days = 30
    model_path = r"C:\Users\DJ akhi\OneDrive\Desktop\sizzlingero\sizzlingeropos(MERGED)\sizzlingeropos\sizzlingeropos\ADMIN\Sales Report\py\trained_model_monthly.json"
else:
    print("Error: Invalid model type")
    sys.exit(1)

with open(model_path, "r") as f:
    model = model_from_json(f.read())

# --- Load input data ---
df = pd.read_csv(data_path)
df = df.rename(columns={'DateTime': 'ds', 'Total': 'y'})
df['ds'] = pd.to_datetime(df['ds'])
df = df.sort_values('ds')

# --- Filter last X days for comparison ---
latest_date = df['ds'].max()
start_date = latest_date - timedelta(days=period_days)
last_period_sales = df[df['ds'].between(start_date, latest_date)]

# --- Group by date for daily totals ---
daily_sales = last_period_sales.groupby(last_period_sales['ds'].dt.date)['y'].sum()

# --- Total sales for the last period ---
current_total = daily_sales.sum()

# --- Forecast future ---
future = model.make_future_dataframe(periods=period_days, freq='D')
forecast = model.predict(future)

# --- Slice future forecast for the next period ---
future_forecast = forecast[forecast['ds'] > df['ds'].max()]
next_period_forecast = future_forecast.head(period_days)

# --- Compute summary ---
Ave_sales = next_period_forecast['yhat'].sum()
Worst = next_period_forecast['yhat_lower'].sum()
Best = next_period_forecast['yhat_upper'].sum()

# --- Output for WinForms ---
# Format: Current Total, Average Forecast, Best, Worst
print(f"{current_total:.2f},{Ave_sales:.2f},{Best:.2f},{Worst:.2f}")
