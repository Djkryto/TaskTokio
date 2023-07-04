import { View } from './View/View'
import React, { Component }  from 'react'
import { TableContextProvider } from "../Context/TableContext"

export const Page = () => {
    return   ( 
        <TableContextProvider>
            <View />
        </TableContextProvider>
    )
}