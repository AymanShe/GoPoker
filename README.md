# GoPoker


### API instructions

- Start a game **[POST]/api/Games**
- End a game **[DELETE]/api/Games/{gameId}**
- Add a deck to a game **[PUT]/api/ShoeCards/{shoeId}/AddDeck**
- Add player to Game **[POST]/api/Players**
  - Example Body:
  {
    "gameId": 5
  }
- Remove a player **[DELETE]/api/Players/{playerId}**
- Deal a card to a player **[PUT]/api/Shoes/{shoeId}/deal/{playerId}**
- Get card of a player **[GET]/api/Players/{playerId}**
- Get game players **[GET]/api/Games/{gameId}/Players** *(not fully implemented)*
- Get undealt cards per suit **[GET]/api/ShoeCards/{shoeId}/Suit**
- Get count of each undealt card **[GET]/api/ShoeCards/{shoeId}/All**  *(not fully implemented)*
- Shuffle deck **[PUT]/api/Shoes/{shoeId}/shuffle**




### Solution
#### Clean Architecture approuch



### TODO:
- Add Unit and Integration tests.
- Add validation (FluentValidation).
- Add documentation.
- Enhance the API design.
- Lint and clean up.
- Add docker scipt.
- use Asyncorounouse methods.
- Create custom exceptions and solidify handling them.
