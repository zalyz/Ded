import React, {useContext} from 'react';
import './Users.styles.css'
import {MyContext} from "../../App";
import User from "../User/User";
import './Users.styles.css'
import {useHistory} from "react-router-dom";

const Users = () => {
  const {users} = useContext(MyContext)
  const history = useHistory()

  const createUserClickHandler = () => {
    history.push('/new-user')
  }

  return (
    <div className={'users__wrapper'}>
      <div><h1>Users</h1></div>
      <button className={'user__create-user'} onClick={createUserClickHandler}>Create new user</button>
      <div className={'user-list__wrapper'}>
        {users.map((user) => <User key={user.Id}
           Id={user.Id}
           FullName={user.FullName}
           PassportNumber={user.PassportNumber} />)}
      </div>
    </div>
  );
};

export default Users;