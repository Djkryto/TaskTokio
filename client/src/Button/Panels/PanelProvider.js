import React, { Component,useState,createContext, useEffect }  from 'react';
import { instanceRepository } from '../../Reuqst/Repository';

export const RequestRepository = instanceRepository();

const panelInit = {
    addShow: false,
    removeShow: false,
    setAddShow: ()=> {},
    setRemoveShow: () => {}
}

export const PanelContext = createContext(panelInit)

export const PanelProvider = ({children}) => {

    const [addShow,setAddShow] = useState(false)
    const [removeShow,setRemoveShow] = useState(false)
    const data = {addShow,removeShow,setAddShow,setRemoveShow}

    useEffect(()=> {},[addShow,removeShow])
    
    return (
            <PanelContext.Provider value={data}>
                {children}
            </PanelContext.Provider>
        )
}
