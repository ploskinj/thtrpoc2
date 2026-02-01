from typing import Optional
from uuid import UUID
from pydantic import BaseModel

class Star(BaseModel):
    id: UUID
    handle: str
    first_name: str
    last_name: str
    backstory: str
