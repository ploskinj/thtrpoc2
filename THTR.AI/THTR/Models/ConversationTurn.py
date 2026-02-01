from typing import Optional
from uuid import UUID
from pydantic import BaseModel
from Character import Character
from Star import Star
from ConversantTypes import ConversantType

class ConversationTurn(BaseModel):
    id: UUID
    utterance: str
    conversant_id: UUID
    conversant_type: ConversantType

    class Config:
        extra = "forbid"