import { Add } from '../Panels/Add'
import { Remove } from '../Panels/Remove'
import React, { Component, useContext }  from 'react'
import { PanelContext } from '../../Context/PanelProvider'

export const Buttons = () => {
    const {addShow,setAddShow,removeShow,setRemoveShow} = useContext(PanelContext)

    return(
        <div>
            <div className='panel-buttons'>
                <button className='add-button' onClick={() => setAddShow(true)}>Добавить</button>
                <button className='add-remove' onClick={() => setRemoveShow(true)}>Удалить</button>
            </div>
            <div>
                <Add show = {addShow}/>
                <Remove show = {removeShow}/>
            </div>
        </div>
    );
}