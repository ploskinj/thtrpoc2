-- THTR001.sql
-- Initial schema creation script
-- Generated from THTR.Common.Entities

-- ============================================
-- character
-- ============================================
CREATE TABLE character (
    id UUID PRIMARY KEY,
    first_name TEXT,
    last_name TEXT,
    backstory TEXT,
    age INTEGER,
    location TEXT,
    identity TEXT,
    education TEXT,
    occupation TEXT,
    family TEXT,
    personality TEXT,
    worldview TEXT,
    create_date TIMESTAMP NOT NULL,
    update_date TIMESTAMP NOT NULL
);

-- ============================================
-- conversation
-- ============================================
CREATE TABLE conversation (
    id UUID PRIMARY KEY,
    title TEXT,
    summary TEXT,
    create_date TIMESTAMP NOT NULL,
    update_date TIMESTAMP NOT NULL
);

-- ============================================
-- star
-- ============================================
CREATE TABLE star (
    id UUID PRIMARY KEY,
    character_id UUID NOT NULL REFERENCES character(id),
    handle TEXT,
    create_date TIMESTAMP NOT NULL,
    update_date TIMESTAMP NOT NULL
);

-- ============================================
-- conversation_turn
-- ============================================
CREATE TABLE conversation_turn (
    id UUID PRIMARY KEY,
    conversation_id UUID NOT NULL REFERENCES conversation(id),
    conversant_id UUID NOT NULL,
    conversant_type INTEGER NOT NULL,
    content TEXT,
    turn_order INTEGER NOT NULL,
    create_date TIMESTAMP NOT NULL,
    update_date TIMESTAMP NOT NULL
);

-- ============================================
-- set_2d
-- ============================================
CREATE TABLE set_2d (
    id UUID PRIMARY KEY,
    name TEXT,
    create_date TIMESTAMP NOT NULL,
    update_date TIMESTAMP NOT NULL
);

-- ============================================
-- tile_set
-- ============================================
CREATE TABLE tile_set (
    id UUID PRIMARY KEY,
    name TEXT,
    sprite_sheet_path TEXT,
    create_date TIMESTAMP NOT NULL,
    update_date TIMESTAMP NOT NULL
);

-- ============================================
-- tile
-- ============================================
CREATE TABLE tile (
    id UUID PRIMARY KEY,
    tile_set_id UUID NOT NULL REFERENCES tile_set(id),
    name TEXT,
    ssx INTEGER NOT NULL,
    ssy INTEGER NOT NULL,
    width INTEGER NOT NULL,
    height INTEGER NOT NULL,
    collidable BOOLEAN NOT NULL,
    visible BOOLEAN NOT NULL,
    create_date TIMESTAMP NOT NULL,
    update_date TIMESTAMP NOT NULL
);

-- ============================================
-- set_element_2d
-- ============================================
CREATE TABLE set_element_2d (
    id UUID PRIMARY KEY,
    set_2d_id UUID NOT NULL REFERENCES set_2d(id),
    name TEXT,
    map_x INTEGER NOT NULL,
    map_y INTEGER NOT NULL,
    tile_set_id UUID NOT NULL REFERENCES tile_set(id),
    tile_id UUID NOT NULL REFERENCES tile(id),
    create_date TIMESTAMP NOT NULL,
    update_date TIMESTAMP NOT NULL
);

-- ============================================
-- production_book
-- ============================================
CREATE TABLE production_book (
    id UUID PRIMARY KEY,
    name TEXT,
    set_2d_id UUID NOT NULL REFERENCES set_2d(id),
    create_date TIMESTAMP NOT NULL,
    update_date TIMESTAMP NOT NULL
);

-- ============================================
-- tts_request
-- ============================================
CREATE TABLE tts_request (
    id UUID PRIMARY KEY,
    text TEXT,
    voice_id TEXT,
    create_date TIMESTAMP NOT NULL,
    update_date TIMESTAMP NOT NULL
);
