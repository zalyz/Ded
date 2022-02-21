package com.example.airport.mapper;

import com.example.airport.model.Ticket;
import com.example.airport.model.dto.TicketDto;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Component;

@Component
@RequiredArgsConstructor
public class TicketMapper {

    private final ClientMapper mapper;

    public Ticket mapToTicket(TicketDto dto){
        return Ticket.builder()
                .id(dto.getId())
                .client(mapper.mapToClient(dto.getClient()))
                .departureDate(dto.getDepartureDate())
                .flightNumber(dto.getFlightNumber())
                .price(dto.getPrice())
                .build();
    }

    public TicketDto mapToTicketDto(Ticket entity){
        return TicketDto.builder()
                .id(entity.getId())
                .client(mapper.mapToClientDto(entity.getClient()))
                .departureDate(entity.getDepartureDate())
                .flightNumber(entity.getFlightNumber())
                .price(entity.getPrice())
                .build();
    }
}
