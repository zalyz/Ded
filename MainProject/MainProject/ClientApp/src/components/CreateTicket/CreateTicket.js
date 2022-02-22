import React, {useContext, useState} from 'react';
import './CreateTicket.styles.css'
import {MyContext} from "../../App";
import {useHistory} from "react-router-dom";

const CreateTicket = () => {
  const {tickets, setTickets, users} = useContext(MyContext)
  const usersId = users.map((user) => user.Id)
  const history = useHistory()
  const [formValues, setFormValues] = useState({
    FlightNumber: '',
    ClientId: '',
    DepartureDate: '',
    Price: 500
  })

  const submitHandler = (event) => {
   event.preventDefault()
    setTickets([...tickets, {id: Math.random() * (99999999 - 1) + 1,
      FlightNumber: formValues.FlightNumber,
      ClientId: formValues.ClientId,
      DepartureDate: formValues.DepartureDate,
      Price: formValues.Price}])
    history.push('/')
  }

  return (
    <div className={'form-wrapper'}>
      <form className={'form'} onSubmit={submitHandler}>
        <h3>Create new ticket</h3>
        <div className={'input-block'}>
          <p>Flight number</p>
          <input value={formValues.FlightNumber} required={true} onChange={(event) => setFormValues({...formValues, FlightNumber: event.target.value})} />
        </div>
        <div className={'input-block'}>
          <p>Client id</p>
          <select onChange={(event) => setFormValues({...formValues, ClientId: event.target.value})}>
            {usersId.map((id) => (
              <option>{id}</option>
              )
            )}
          </select>
        </div>
        <div className={'input-block'}>
          <p>Date</p>
          <input type={'date'} value={formValues.DepartureDate} onChange={(event) => setFormValues({...formValues, DepartureDate: event.target.value})} />
        </div>
        <div className={'input-block'}>
          <p>Price</p>
          <input type={"number"} value={formValues.Price} onChange={(event) => setFormValues({...formValues, Price: event.target.value})} />
        </div>
        <button className={'form-submit'}>Create</button>
      </form>
    </div>
  );
};

export default CreateTicket;