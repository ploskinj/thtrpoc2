from typing import Optional
from uuid import UUID

from langsmith import uuid
from pydantic import BaseModel
from Character import Character
from Star import Star

class Conversation(BaseModel):
    id: UUID
    stars: list[UUID]
    extras : list[UUID]
    turns: list[UUID]
    summary: str

    class Config:
        extra = "forbid"