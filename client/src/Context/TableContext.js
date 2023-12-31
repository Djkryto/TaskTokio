import React, { Component,useState,createContext }  from 'react'

const initDataTable = {
    arrayOrder: [],
    setArrayOrder: () => {}
}

export const DataTableContext = createContext(initDataTable) 

export const TableContextProvider = ({children}) => {
    const [arrayOrder,setArrayOrder] = useState([])
    const data = {arrayOrder,setArrayOrder}

    return (
        <DataTableContext.Provider value={data}>
            {children}
        </DataTableContext.Provider>
    )
}