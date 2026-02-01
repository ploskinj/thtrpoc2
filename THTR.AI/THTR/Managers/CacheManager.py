
import redis.asyncio as redis

class CacheManager():

    _redis_pool = None

    def initialize(self):
        # Adding a 5-second timeout so your API doesn't hang forever if the Pi is down
        self._redis_pool = redis.from_url(
            "redis://:THTRD3V97#@10.0.0.52:6379",
            decode_responses=True,
            socket_timeout=5.0,
            socket_connect_timeout=5.0
        )