import { PanelContext } from '../../Context/PanelProvider'
import { instanceRepository } from '../../Reuqst/Repository'
import { DataTableContext } from '../../Context/TableContext'
import React, { Component, useContext, useRef }  from 'react'

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