
// export default class App extends Component {
//   static displayName = App.name;
//
//   render () {
//     return (
//       <Layout>
//         <Route exact path='/' component={Home} />
//         <Route exact path='/new-ticket' component={CreateTicket} />
//       </Layout>
//     );
//   }
// }

import React, {useState} from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import Home from './components/Home';
import './custom.css'
import CreateTicket from "./components/CreateTicket/CreateTicket";

export const MyContext = React.createContext(null);

const App = () => {
  const [tickets, setTickets] = useState([
    {
      Id: 1,
      FlightNumber: 1111,
      ClientId: 123,
      DepartureDate: new Date(2021, 2, 14),
      Price: 1000
    },
    {
      Id: 2,
      FlightNumber: 2222,
      ClientId: 123,
      DepartureDate: new Date(10, 2, 2021),
      Price: 1000
    },
    {
      Id: 3,
      FlightNumber: 3333,
      ClientId: 123,
      DepartureDate: new Date(10, 2, 2021),
      Price: 1200
    },
    {
      Id: 4,
      FlightNumber: 4444,
      ClientId: 123,
      DepartureDate: new Date(10, 2, 2021),
      Price: 300
    },
    {
      Id: 5,
      FlightNumber: 1111,
      ClientId: 123,
      DepartureDate: new Date(2021, 2, 14),
      Price: 1000
    },
    {
      Id: 6,
      FlightNumber: 2222,
      ClientId: 123,
      DepartureDate: new Date(10, 2, 2021),
      Price: 1000
    },
    {
      Id: 7,
      FlightNumber: 3333,
      ClientId: 123,
      DepartureDate: new Date(10, 2, 2021),
      Price: 1200
    },
    {
      Id: 8,
      FlightNumber: 4444,
      ClientId: 123,
      DepartureDate: new Date(10, 2, 2021),
      Price: 300
    },
    {
      Id: 9,
      FlightNumber: 1111,
      ClientId: 123,
      DepartureDate: new Date(2021, 2, 14),
      Price: 1000
    },
    {
      Id: 10,
      FlightNumber: 2222,
      ClientId: 123,
      DepartureDate: new Date(10, 2, 2021),
      Price: 1000
    },
    {
      Id: 11,
      FlightNumber: 3333,
      ClientId: 123,
      DepartureDate: new Date(10, 2, 2021),
      Price: 1200
    },
    {
      Id: 12,
      FlightNumber: 4444,
      ClientId: 123,
      DepartureDate: new Date(10, 2, 2021),
      Price: 300
    }
  ])

  return (
    <div>
      <MyContext.Provider value={{
        tickets, setTickets
      }}>
        <Layout>
          <Route exact path='/' component={Home} />
          <Route exact path='/new-ticket' component={CreateTicket} />
        </Layout>
      </MyContext.Provider>
    </div>
  );
};

export default App;
