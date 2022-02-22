import React, {useContext, useState} from 'react';
import './UpdateUser.styles.css'
import {useHistory, useParams} from "react-router-dom";
import {MyContext} from "../../App";

const UpdateUser = () => {
  const {id} = useParams()
  const history = useHistory()
  const {users, setUsers} = useContext(MyContext)
  const currentUser = users.find((user) => user.Id.toString() === id)
  const [formValues, setFormValues] = useState({
    FullName: currentUser.FullName,
    PassportNumber: currentUser.PassportNumber
  })

  const submitHandler = (event) => {
    event.preventDefault()
    const index = users.indexOf(currentUser)
    let copy = [...users]
    let newItem = {
      ...copy[index],
      FullName: formValues.FullName,
      PassportNumber: formValues.PassportNumber
    }
    copy[index] = newItem
    setUsers(copy)
    history.push('/users')
  }

  return (
    <div className={'update-ticket__wrapper'}>
      {currentUser ? (
          <form className={'update-ticket__form'} onSubmit={submitHandler}>
            <h3>Update ticket ticket</h3>
            <div className={'input-block'}>
              <p>Full name</p>
              <input value={formValues.FullName} onChange={(event) => setFormValues({...formValues, FullName: event.target.value})} />
            </div>
            <div className={'input-block'}>
              <p>Passport number</p>
              <input value={formValues.PassportNumber} onChange={(event) => setFormValues({...formValues, PassportNumber: event.target.value})} />
            </div>
            <button className={'form__button'}>Update</button>
          </form>) :
        <h2>User not found</h2>}
    </div>
  );
};

export default UpdateUser;