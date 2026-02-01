from THTR.Managers import CacheManager
from THTR.Models import *

class ConversationManager(object):

    _cache_manager = None

    def __init__(self, cacheManager : CacheManager):
        self._cache_manager = cacheManager

    def startConversation(self):
        new_con = Conversation()
