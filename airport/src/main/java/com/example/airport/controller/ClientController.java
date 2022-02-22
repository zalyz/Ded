package com.example.airport.controller;

import com.example.airport.model.dto.ClientDto;
import com.example.airport.service.ClientService;
import lombok.RequiredArgsConstructor;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequiredArgsConstructor
@RequestMapping("/client")
public class ClientController {

    private final ClientService service;

    @GetMapping("/all")
    public List<ClientDto> findAll(){
        return service.findAll();
    }

    @GetMapping("/find/{id}")
    public ClientDto findById(@PathVariable(name = "id") Long id){
        return service.findById(id);
    }

    @PostMapping("/save")
    public Long save(@RequestBody ClientDto dto){
        return service.save(dto);
    }

    @DeleteMapping("/delete/{id}")
    public void delete(@PathVariable(name = "id") Long id){
        service.deleteById(id);
    }

    @PutMapping("/update")
    public void update(@RequestBody ClientDto dto){
        service.update(dto);
    }
}
