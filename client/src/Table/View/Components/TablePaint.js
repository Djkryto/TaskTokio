import React, { Component,useContext,useEffect }  from 'react';
import { pathReuqst } from "../../../Enum/PathReuqst"
import {DataTableContext} from '../../../Context/TableContext'
import { instanceRepository } from '../../../Reuqst/Repository'

let order =
{
  Id: 1,
  Name: "WDASD",
  Client: "WW",
  Price:  332
}

export const TablePaint = () =>{
    const repository = instanceRepository();
    const {arrayOrder,setArrayOrder} = useContext(DataTableContext)
    const rows = []
    
    useEffect(()=>{ 
        repository.Get(setArrayOrder);
    },[])

    useEffect(()=>{},[arrayOrder])

    if(arrayOrder[0] != null){
        for (var i = 0; i < arrayOrder.length; i++){
            rows.push(
            <tr key ={i * i * i + 1}>
                <th key={i * i + 2} id={i + i}>{ arrayOrder[i].id }</th> 
                <th key={i * i + 3} id={i + i}>{ arrayOrder[i].name }</th> 
                <th key={i* i + 4} id={i + i}>{ arrayOrder[i].client }</th> 
                <th key={i* i + 5} id={i + i}>{ arrayOrder[i].price }</th> 
            </tr>
            )
        }
    }

    return (        
    <div>
        <table>
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Название заказа</th>
                    <th>ФИО Клиента</th>
                    <th>Цена</th>
                </tr>
            </thead>
            <tbody>
                {rows}
            </tbody>
            
        </table>
    </div>)
}