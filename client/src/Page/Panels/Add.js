
import { PanelContext } from '../../Context/PanelProvider'
import { instanceRepository } from '../../Reuqst/Repository'
import React, { Component, useContext, useRef }  from 'react'

const sendData = (name,client,price) =>{
    const repository = instanceRepository();
    const order = {id: 0 ,name: name.current.value, client: client.current.value, price: price.current.value}
    repository.Add(order)
    window.location.reload()
}

export const Add = () => {
    const {addShow,setAddShow} = useContext(PanelContext)
    const name = useRef("")
    const client = useRef("")
    const price = useRef(0)

    return(addShow ?
            <div className='panel'>
                <button className='close-button' onClick={() => setAddShow(false)}>X</button>
                <text>Название</text>
                <input id='name' ref={name}></input>
                <text>ФИО</text>
                <input id='client' ref={client}></input>
                <text>Цена</text>
                <input id='price' ref={price}></input>
                <button onClick={() => sendData(name,client,price)}>Добавить</button>
            </div>        
        : null
    )
}