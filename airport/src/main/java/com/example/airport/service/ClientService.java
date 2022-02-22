package com.example.airport.service;

import com.example.airport.exception.ClientException;
import com.example.airport.mapper.ClientMapper;
import com.example.airport.model.Client;
import com.example.airport.model.dto.ClientDto;
import com.example.airport.repository.ClientRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
@RequiredArgsConstructor
public class ClientService {

    private final ClientRepository clientRepository;
    private final ClientMapper mapper;
    private static final String CLIENT_NOT_FOUND_MESSAGE = "Client with %s was not found";

    public List<ClientDto> findAll() {
        return clientRepository.findAll().stream()
                .map(mapper::mapToClientDto)
                .collect(Collectors.toList());
    }


    public ClientDto findById(Long id) {
        return clientRepository.findById(id)
                .map(mapper::mapToClientDto)
                .orElseThrow(() -> new ClientException(String.format(CLIENT_NOT_FOUND_MESSAGE, id)));
    }


    public Long save(ClientDto dto) {
        Client entity = mapper.mapToClient(dto);
        entity = clientRepository.save(entity);
        return entity.getId();
    }

    public void update(ClientDto dto){
        clientRepository.save(mapper.mapToClient(dto));
    }

    public void deleteById(Long id) {
        clientRepository.deleteById(id);
    }

}
