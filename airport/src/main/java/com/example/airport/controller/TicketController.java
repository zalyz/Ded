package com.example.airport.controller;

import com.example.airport.model.dto.TicketDto;
import com.example.airport.service.TicketService;
import lombok.RequiredArgsConstructor;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/ticket")
@RequiredArgsConstructor
public class TicketController {

    private final TicketService service;

    @GetMapping("/all")
    public List<TicketDto> findAll(){
        return service.findAll();
    }

    @GetMapping("/find/{id}")
    public TicketDto findById(@PathVariable(name = "id") Long id){
        return service.findById(id);
    }

    @PostMapping("/save")
    public TicketDto save(@RequestBody TicketDto dto){
        return service.save(dto);
    }

    @DeleteMapping("/delete/{id}")
    public void deleteById(@PathVariable(name = "id") Long id){
        service.deleteById(id);
    }
}
