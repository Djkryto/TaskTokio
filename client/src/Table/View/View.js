import React, { FC, useEffect } from 'react'
import { instanceRepository } from '../../Reuqst/Repository'
import {TablePaint} from './Components/TablePaint'
import {Add} from '../../Reuqst/Repository'



export const View = () => {
    return (
        <div>
            <TablePaint/>
        </div>
    )
}