from enum import Enum
from pydantic import BaseModel

class ConversantType(int, Enum):
    STAR = 0
    EXTRA = 1