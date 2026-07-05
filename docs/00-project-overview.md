# UNO Bot Remake — Project Overview

## Summary

This project is a C# / Discord.NET remake of the original Ratismal UNO Discord bot.

The goal is to create a Discord bot that lets users play UNO inside a Discord channel using text commands, direct messages, and public game updates.

The first version should focus on legacy compatibility. By default, the remake should behave as closely as possible to the original bot from the user's point of view.

## Main Goal

Rebuild the original UNO Discord bot in C# using Discord.NET while preserving the original user experience.

This means the default behavior should keep:

- the same commands,
- the same command aliases,
- the same public messages,
- the same direct messages,
- the same game flow,
- the same default rules,
- the same card behavior,
- the same timeout behavior where practical.

## Non-Goal for the First Version

The first version is not trying to create a modernized UNO bot.

The following should be treated as future features, not MVP requirements:

- slash-command-first gameplay,
- button-based gameplay,
- custom card themes,
- achievements,
- player statistics,
- matchmaking,
- web dashboards,
- AI players,
- advanced house rules.

These may be added later, but the initial bot should first prove that the original experience can be recreated.

## Compatibility Principle

When the original bot does something strange, the remake should copy it first.

Improvements should be added later behind configuration options or modern mode settings.

Example:

```text
LegacyCompatibilityMode = true
```

When this mode is enabled, the bot should prioritize matching the original behavior over making the behavior cleaner or more modern.

## Technical Direction

The bot will use the existing Discord.NET template as its foundation.

The project should keep the template's existing structure and add UNO-specific services, models, commands, and persistence.

The UNO game engine should be kept mostly separate from Discord.NET-specific code so it can be tested without needing a live Discord bot connection.

## First Milestone

The first milestone is a playable compatibility MVP.

A successful MVP should allow users to:

1. Create a game with `uno join`.
2. Join a game with `uno join`.
3. Start a game with `uno start`.
4. Receive cards by DM.
5. View their hand with `uno hand`.
6. Play cards with `uno play`.
7. Draw cards with `uno pickup` / `uno draw`.
8. Say UNO with `uno!`.
9. Call out players with `uno callout`.
10. Finish a game and receive the scoreboard.

## Guiding Rule

Do not add new features until the legacy behavior is documented and working.
