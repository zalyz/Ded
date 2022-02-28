import React from 'react';
import {useHistory} from "react-router-dom";

const Ticket = ({Id, FlightNumber, ClientId, DepartureDate, Price, tickets, setTickets}) => {
  const history = useHistory()

  const clickRemoveButtonHandler = async () => {
    const req = await fetch(`https://localhost:44320/api/Ticket/${Id}`, {
      method: 'DELETE',
      headers: {
        'Content-Type': 'application/json;charset=utf-8'
      },
    })

    const newArr = tickets.filter((ticket) => ticket.Id !== Id)
    setTickets(newArr)
  }

  const clickUpdateButtonHandler = () => {
    history.push(`/update-ticket/${Id}`)
  }

  return (
    <div className={'home__ticket'}>
      <div>
        <p>Flight number: {FlightNumber}</p>
        <p>ClientId: {ClientId}</p>
      </div>
      <div>
        <p>Date: {new Date(DepartureDate).toDateString()}</p>
        <p>Price: {Price}$</p>
      </div>
      <div className={'home-ticket__button-wrapper'}>
        <button className={'btn btn-info'} onClick={clickUpdateButtonHandler}>Update</button>
        <button className={'btn btn-danger'} onClick={clickRemoveButtonHandler}>Remove</button>
      </div>
    </div>
  );
};

export default Ticket;