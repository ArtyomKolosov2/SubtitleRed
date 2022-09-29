import {loginFailure, loginStart, loginSuccess, logout} from "./userRedux";
import {publicRequest} from "../requestMethods";
import {clean} from "./cartRedux";

export const login = async (dispatch, user) => {
    dispatch(loginStart());
    try {
        const res = await publicRequest.post("/login", user, {withCredentials: true})
        dispatch(loginSuccess(res.data))
        console.log(res.headers)
    } catch (e) {
        dispatch(loginFailure())
    }
}

export const logOut = (dispatch) => {
    dispatch(logout());
}

export const cleanCart = (dispatch) => {
    dispatch(clean())
}