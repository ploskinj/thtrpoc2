import redis
from fastapi import FastAPI
from contextlib import asynccontextmanager
from .THTR.Managers.CacheManager import CacheManager
import os
from dotenv import load_dotenv


@asynccontextmanager
async def lifespan(app: FastAPI):
    # --- STARTUP LOGIC ---
    # Instantiate your class (assuming it takes the URL from env)
    load_dotenv()
    cache_manager = CacheManager()
    cache_manager.initialize()
    app.state.cache_manager = cache_manager
    print("Redis CacheManager is ready!")

    yield  # The app stays here while it's running

    # --- SHUTDOWN LOGIC ---
    # await cache_manager.close()
    print("Shutting down Redis connection...")


app = FastAPI()



@app.get("/")
async def root():
    return {"message": "Hello World"}


@app.get("/hello/{name}")
async def say_hello(name: str):
    return {"message": f"Hello {name}"}
