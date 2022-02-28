import React, {useContext, useState} from 'react';
import './CreateUser.styles.css'
import {MyContext} from "../../App";
import {useHistory} from "react-router-dom";

const CreateUser = () => {
  const {users, setUsers} = useContext(MyContext)
  const [formValues, setFormValues] = useState({
    FullName: '',
    PassportNumber: ''
  })
  const history = useHistory()

  const submitHandler = async (event) => {
    event.preventDefault()
    const req = await fetch(`https://localhost:44320/api/Client`, {
      method: 'POST',
      headers: {
        headers: {
          'Content-Type': 'application/json;charset=utf-8'
        },
      },
      body: {
        FullName: formValues.FullName,
        PassportNumber: formValues.PassportNumber
      }
    })
    const clientId = await req.json()
    setUsers([...users, {id: clientId,
      FullName: formValues.FullName,
      PassportNumber: formValues.PassportNumber}])
    history.push('/users')
  }

  return (
    <div className={'form-wrapper'}>
      <form className={'form'} onSubmit={submitHandler}>
        <h3>Create new user</h3>
        <div className={'input-block'}>
          <p>Full name</p>
          <input value={formValues.FullName} required={true} onChange={(event) => setFormValues({...formValues, FullName: event.target.value})} />
        </div>
        <div className={'input-block'}>
          <p>Passport number</p>
          <input value={formValues.PassportNumber} required={true} onChange={(event) => setFormValues({...formValues, PassportNumber: event.target.value})} />
        </div>
        <button className={'form-submit'}>Create</button>
      </form>
    </div>
  );
};

export default CreateUser;