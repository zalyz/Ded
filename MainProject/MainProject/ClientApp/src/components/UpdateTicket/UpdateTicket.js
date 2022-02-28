import React, {useContext, useState} from 'react';
import {useHistory, useParams} from "react-router-dom";
import {MyContext} from "../../App";
import './UpdateTicket.styles.css'

const UpdateTicket = () => {
  const {id} = useParams()
  const history = useHistory()
  const {tickets, setTickets, users} = useContext(MyContext)
  const usersId = users.map((user) => user.Id)
  const currentTicket = tickets.find((ticket) => ticket.Id.toString() === id)
  const [formValues, setFormValues] = useState({
    FlightNumber: currentTicket.FlightNumber,
    ClientId: currentTicket.ClientId,
    DepartureDate: currentTicket.DepartureDate,
    Price: currentTicket.Price
  })

  const submitHandler = async (event) => {
    event.preventDefault()
    const req = await fetch('https://localhost:44320/api/Ticket',{
      method: 'PATCH',
      headers: {
        headers: {
          'Content-Type': 'application/json;charset=utf-8'
        },
      },
      body: {
        Id: id,
        FlightNumber: formValues.FlightNumber,
        ClientId: formValues.ClientId,
        DepartureDate: formValues.DepartureDate,
        Price: formValues.Price
      }
    })

    const index = tickets.indexOf(currentTicket)
    let copy = [...tickets]
    let newItem = {
      ...copy[index],
      FlightNumber: formValues.FlightNumber,
      ClientId: formValues.ClientId,
      DepartureDate: formValues.DepartureDate,
      Price: formValues.Price
    }
    copy[index] = newItem
    setTickets(copy)
    history.push('/')
  }

  return (
    <div className={'update-ticket__wrapper'}>
      {currentTicket ? (
        <form className={'update-ticket__form'} onSubmit={submitHandler}>
          <h3>Update ticket ticket</h3>
          <div className={'input-block'}>
            <p>Flight number</p>
            <input value={formValues.FlightNumber} onChange={(event) => setFormValues({...formValues, FlightNumber: event.target.value})} />
          </div>
          <div className={'input-block'}>
            <p>Client id</p>
            <select onChange={(event) => setFormValues({...formValues, ClientId: event.target.value})}>
              {usersId.map((id) => (
                <option>{id}</option>
              ))}
            </select>
          </div>
          <div className={'input-block'}>
            <p>Date</p>
            <input type={'date'} value={formValues.DepartureDate} onChange={(event) => setFormValues({...formValues, DepartureDate: new Date(event.target.value)})} />
          </div>
          <div className={'input-block'}>
            <p>Price</p>
            <input type={"number"} value={formValues.Price} onChange={(event) => setFormValues({...formValues, Price: event.target.value})} />
          </div>
          <button className={'form__button'}>Update</button>
        </form>) :
      <h2>Ticket not found</h2>}
    </div>
  );
};

export default UpdateTicket;