import React, {useContext} from 'react';
import './User.styles.css'
import {MyContext} from "../../App";
import {useHistory} from "react-router-dom";

const User = ({Id, FullName, PassportNumber}) => {
  const {users, setUsers} = useContext(MyContext)
  const history = useHistory()

  function clickUpdateButtonHandler() {
    history.push(`/update-user/${Id}`)
  }

  async function clickRemoveButtonHandler() {
    const req = await fetch(`https://localhost:44320/api/Client/${Id}`, {
      method: 'DELETE',
      headers: {
        'Content-Type': 'application/json;charset=utf-8'
      },
    })

    const newArr = users.filter((user) => user.Id !== Id)
    setUsers(newArr)
  }

  return (
    <div className={'user'}>
      <div>
        <p>Full name:  {FullName}</p>
        <p>PassportNumber:  {PassportNumber}</p>
      </div>
      <div className={'home-ticket__button-wrapper'}>
        <button className={'btn btn-info'} onClick={clickUpdateButtonHandler}>Update</button>
        <button className={'btn btn-danger'} onClick={clickRemoveButtonHandler}>Remove</button>
      </div>
    </div>
  );
};

export default User;