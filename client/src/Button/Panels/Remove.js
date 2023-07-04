import React, { Component,useEffect,useContext, useRef }  from 'react'
import { PanelContext } from './PanelProvider';
import { PageContext } from '../../Context/TableContext';
import { DataTableContext } from '../../Context/TableContext';
import '../../Css/button.css'
import { instanceRepository } from '../../Reuqst/Repository';

export const Remove = () => {
    const {removeShow,setRemoveShow} = useContext(PanelContext)
    const {arrayOrder} = useContext(DataTableContext)
    const id = useRef("")

    return(removeShow ? 
            <div className='panel'>
                <button className='close-button' id = 'close-button' onClick={() => setRemoveShow(false)}>X</button>
                <text>Id</text>
                <input id='id' ref={id}></input>
                <button id ="button-action" onClick={()=> findOrder(arrayOrder,id)}>Удалить</button>
            </div>
        : null
    );
}

const findOrder = (arrayOrder,id)=>{
    const repository = instanceRepository();
    let order = null;

    for(let i = 0; i < arrayOrder.length;i++){
       if(id.current.value == arrayOrder[i].id){
            order = arrayOrder[i]
            break;
       }
    }

    repository.Remove(order)
    window.location.reload()
}