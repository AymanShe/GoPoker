﻿using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ShoeService : IShoeService
    {
        private readonly IShoeRepository _shoeRepository;
        private readonly IShoeCardRepository _shoeCardRepository;
        private readonly IPlayerCardService _playerCardService;
        private readonly IMapper _mapper;

        public ShoeService(IShoeRepository shoeRepository, IShoeCardRepository shoeCardRepository, IPlayerCardService playerCardService, IMapper mapper)
        {
            _shoeRepository = shoeRepository;
            _shoeCardRepository = shoeCardRepository;
            _playerCardService = playerCardService;
            _mapper = mapper;
        }


        public PlayerCardDto DealCardToPlayer(int playerId)
        {
            // Get the card info from show
            var shoeCard = _shoeCardRepository.GetAll().FirstOrDefault();
            if (shoeCard == null)
            {
                throw new NotImplementedException();// No more cards
            }

            // Convert it into a card for the player
            var PlayerCard = new PlayerCard
            {
                PlayerId = playerId,
                Rank = shoeCard.Rank,
                Suit = shoeCard.Suit
            };
            var playerCardDto = _playerCardService.AssignCardToPlayer(_mapper.Map<PlayerCardDto>(PlayerCard));

            // Remove the card from the shoe
            _shoeCardRepository.Delete(shoeCard);

            return playerCardDto;
        }

        public void UpdateNumberOfDecksAfterAdding(int shoeId)
        {
            var shoe = _shoeRepository.GetById(shoeId);
            if(shoe == null)
            {
                throw new NotImplementedException();
            }

            shoe.NumberOfDecks++;

            _shoeRepository.Update(shoe);
        }

        public void ShuffleCard(int shoeId)
        {
            throw new NotImplementedException();
        }

        
    }
}