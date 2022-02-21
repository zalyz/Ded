package com.example.airport.mapper;

import com.example.airport.model.Client;
import com.example.airport.model.dto.ClientDto;
import org.springframework.stereotype.Component;

@Component
public class ClientMapper {

    public Client mapToClient(ClientDto dto){
        return Client.builder()
                .id(dto.getId())
                .fullName(dto.getFullName())
                .passportNumber(dto.getPassportNumber())
                .build();
    }

    public ClientDto mapToClientDto(Client entity){
        return ClientDto.builder()
                .id(entity.getId())
                .fullName(entity.getFullName())
                .passportNumber(entity.getPassportNumber())
                .build();
    }
}
