package com.example.airport.model.dto;

import com.example.airport.model.Client;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDate;

@Data
@NoArgsConstructor
@AllArgsConstructor
@Builder
public class TicketDto {
    private Long id;
    private Long flightNumber;
    private ClientDto client;
    private LocalDate departureDate;
    private Integer price;
}
