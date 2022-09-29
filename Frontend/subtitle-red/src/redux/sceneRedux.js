import {createSlice} from "@reduxjs/toolkit";

const userRedux = createSlice({
    name: "scene",
    initialState: {
        sceneList: [],
        count: 0,
        isFetching: false,
        error: false,
    },
    reducers: {
        addScene: (state, action) => {
            state.count += 1;
            state.sceneList.push(action.payload);
        },
        clean: (state) => {
            state.sceneList = [];
            state.count = 0;
        },
        incSceneQuantity: (state, action) => {
            state.sceneList = state.sceneList.forEach(item => {
                if (item.id === action.payload.id) item.count += 1
            });
        }
    },
});

export const {loginStart, loginSuccess, loginFailure, logout} = userRedux.actions;
export default userRedux.reducer;