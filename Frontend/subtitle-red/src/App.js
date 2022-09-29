import {BrowserRouter as Router, Link, Redirect, Route, Switch} from "react-router-dom";
import './App.css';

const App = () => {
    const user = useSelector(state => state.user.currentUser)
    
    return (
        <Router>
            <Switch>
                <Route exact path="/">
                    {user ? <Home/> : <Redirect to="/login"/>}
                </Route>
                <Route path="/login">
                    {user ? <Redirect to="/"/> : <Login/>}
                </Route>
                <Route path="/register">
                    {user ? <Redirect to="/"/> : <Register/>}
                </Route>
            </Switch>
        </Router>
    );
}

export default App;
