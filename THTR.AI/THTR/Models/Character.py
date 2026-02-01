from typing import Optional
from uuid import UUID
from pydantic import BaseModel

class Character(BaseModel):
    id: UUID

    first_name: Optional[str] = None
    last_name: Optional[str] = None
    backstory: Optional[str] = None

    age: Optional[int] = None
    location: Optional[str] = None
    identity: Optional[str] = None
    education: Optional[str] = None
    occupation: Optional[str] = None
    family: Optional[str] = None
    personality: Optional[str] = None
    worldview: Optional[str] = None

    class Config:
        extra = "forbid"