import React, { Component }  from 'react'
import { Buttons } from '../Button/Button'
import {TablePaint} from './Components/TablePaint'
import { PanelProvider } from '../../Context/PanelProvider'


export const View = () => {
    return (
        <div>
            <TablePaint/>
            <PanelProvider>
                <Buttons />
            </PanelProvider>
        </div>
    )
}