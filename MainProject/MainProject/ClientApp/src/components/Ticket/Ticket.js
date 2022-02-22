import React from 'react';

const Ticket = ({Id, FlightNumber, ClientId, DepartureDate, Price, tickets, setTickets}) => {
  const clickRemoveButtonHandler = () => {
    const newArr = tickets.filter((ticket) => ticket.Id !== Id)
    setTickets(newArr)
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
        <button className={'btn btn-info'}>Update</button>
        <button className={'btn btn-danger'} onClick={clickRemoveButtonHandler}>Remove</button>
      </div>
    </div>
  );
};

export default Ticket;