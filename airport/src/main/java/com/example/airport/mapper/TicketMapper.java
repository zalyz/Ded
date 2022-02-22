package com.example.airport.mapper;

import com.example.airport.model.Ticket;
import com.example.airport.model.dto.TicketDto;
import org.springframework.stereotype.Component;

@Component
public class TicketMapper {
    public Ticket mapToTicket(TicketDto dto){
        return Ticket.builder()
                .id(dto.getId())
                .clientId(dto.getClientId())
                .departureDate(dto.getDepartureDate())
                .flightNumber(dto.getFlightNumber())
                .price(dto.getPrice())
                .build();
    }

    public TicketDto mapToTicketDto(Ticket entity){
        return TicketDto.builder()
                .id(entity.getId())
                .clientId(entity.getClientId())
                .departureDate(entity.getDepartureDate())
                .flightNumber(entity.getFlightNumber())
                .price(entity.getPrice())
                .build();
    }
}
