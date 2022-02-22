package com.example.airport.service;

import com.example.airport.exception.TicketException;
import com.example.airport.mapper.TicketMapper;
import com.example.airport.model.Ticket;
import com.example.airport.model.dto.TicketDto;
import com.example.airport.repository.TicketRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
@RequiredArgsConstructor
public class TicketService {

    private final TicketRepository repository;
    private final TicketMapper mapper;
    private static final String TICKET_EXCEPTION_MESSAGE = "Ticket with %s id was not found";

    public List<TicketDto> findAll() {
        return repository.findAll().stream()
                .map(mapper::mapToTicketDto)
                .collect(Collectors.toList());
    }

    public TicketDto findById(Long id) {
        return repository.findById(id).
                map(mapper::mapToTicketDto)
                .orElseThrow(() -> new TicketException(String.format(TICKET_EXCEPTION_MESSAGE, id)));
    }

    public TicketDto save(TicketDto dto) {
        Ticket entity = mapper.mapToTicket(dto);
        entity = repository.save(entity);
        return mapper.mapToTicketDto(entity);
    }

    public void deleteById(Long id) {
        repository.deleteById(id);
    }

    public void update(TicketDto dto){
        repository.save(mapper.mapToTicket(dto));
    }

}
