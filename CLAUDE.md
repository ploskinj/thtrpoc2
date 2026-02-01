# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

THTR is a hybrid .NET/Python full-stack application for theater/production management with AI-powered conversational features. The system uses a microservices architecture with shared DTOs.

## Coding Style Guide

**Naming Conventions (all languages: C#, Python, JavaScript, SQL):**
- Use `snake_case` for all property, variable, and function names
- Private class properties always start with `_` (e.g., `_cache_manager`)

**C# DTOs:**
- Always use `[JsonPropertyName("property_name")]` attributes on all properties

**PostgreSQL:**
- All table and column names are lowercase `snake_case`
- All entity tables must have: `id` (guid), `create_date`, `update_date`

**Examples:**
```csharp
// C# DTO
public class Character
{
    [JsonPropertyName("character_id")]
    public Guid character_id { get; set; }

    [JsonPropertyName("create_date")]
    public DateTime create_date { get; set; }
}
```
```python
# Python
class ConversationManager:
    def __init__(self):
        self._cache_manager = None

    def get_conversation_by_id(self, conversation_id):
        pass
```
```sql
-- PostgreSQL
CREATE TABLE character (
    id UUID PRIMARY KEY,
    character_name VARCHAR(255),
    create_date TIMESTAMP,
    update_date TIMESTAMP
);
```

## Build and Run Commands

**Build the entire solution:**
```bash
dotnet build THTR.TownDemo.slnx
```

**Run individual services:**

| Service | Command | URL |
|---------|---------|-----|
| Web UI (MVC) | `dotnet run --project THTR.Client.Web` | http://localhost:5026 |
| Game API | `dotnet run --project THTR.Game` | http://localhost:5268 |
| Persistence API | `dotnet run --project THTR.Persist` | http://localhost:5268 |
| AI Service | `cd THTR.AI && uvicorn main:app --reload` | http://localhost:8000 |

## Architecture

```
┌─────────────────┐     ┌─────────────────┐
│ THTR.Client.Web │     │    THTR.AI      │
│  (ASP.NET MVC)  │     │ (Python/FastAPI)│
└────────┬────────┘     └────────┬────────┘
         │                       │
         ▼                       ▼
┌─────────────────┐     ┌─────────────────┐
│   THTR.Game     │     │     Redis       │
│  (ASP.NET API)  │     │  (10.0.0.52)    │
└────────┬────────┘     └─────────────────┘
         │
         ▼
┌─────────────────┐     ┌─────────────────┐
│  THTR.Persist   │────▶│   PostgreSQL    │
│  (ASP.NET API)  │     │  (10.0.0.52)    │
└─────────────────┘     └─────────────────┘
         ▲
         │
┌─────────────────┐
│  THTR.Common    │ ◀── Shared DTOs across all .NET services
│ (Class Library) │
└─────────────────┘
```

**THTR.Common** is the shared library containing all DTOs - any data model changes here affect multiple services.

## Key Domain Models

- **Character/Star**: Represents people in conversations with detailed attributes (backstory, personality, worldview)
- **Conversation/ConversationTurn**: AI conversation orchestration with support for "stars" (named characters) and "extras"
- **ProductionBook/Set2D**: Theater production and 2D stage set definitions
- **TileSet/SetElement2D**: Sprite-based visual elements with collision and visibility data

## Infrastructure Requirements

- .NET 10.0 SDK
- Python 3.8+ with FastAPI, redis, pydantic, python-dotenv
- PostgreSQL at 10.0.0.52:5432 (database: THTR_Dev)
- Redis at 10.0.0.52:6379

## Project Structure Notes

- `.http` files in THTR.Game and THTR.Persist contain sample API requests for testing
- Python AI service models in `THTR.AI/THTR/Models/` mirror the C# DTOs in `THTR.Common/DTOs/`
- ConversationManager handles AI conversation orchestration; CacheManager handles Redis connections
