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

  const submitHandler = (event) => {
    event.preventDefault()
    setUsers([...users, {id: Math.random(99999999 - 1) + 1,
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