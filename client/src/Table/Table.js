import { View } from './View/View';
import React, { Component }  from 'react';
import { TableContextProvider } from "../Context/TableContext"
import { Buttons } from '../Button/Button';
import { PanelProvider } from '../Button/Panels/PanelProvider';

export const Table = () => {

    return   ( 
        <TableContextProvider>
            <View />
            <PanelProvider>
                <Buttons />
            </PanelProvider>
        </TableContextProvider>
    )
}