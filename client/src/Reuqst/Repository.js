import { pathReuqst } from "../Enum/PathReuqst"
import { initModelXML } from "../Handler/XmlHandler"
import { NameElementXML } from "../Enum/NameElementXML"

const headPost = (data) =>{ 
    return {
        credentials: 'include',
        method: "POST", 
        body: data,
        headers: {'Content-Type': 'text/xml; charset=utf-8'} ,
        credentials: 'include'
        }
}

class Repository{

    Add = async (order) => {
        const data = initModelXML(order);
        await fetch(pathReuqst.Add, headPost(data))
    }
    
    Remove = async (order) => {
        const data = initModelXML(order)
        await fetch(pathReuqst.Remove, headPost(data))
    }
    
    Get = async (setArrayOrder) => {
        const responce = await fetch(pathReuqst.Get)
        const text = await responce.text()
        const document = new window.DOMParser().parseFromString(text, "text/xml")
        const data = []

        const orders = document.getElementsByTagName(NameElementXML.Order)

        for(let i = 0; i < orders.length;i++)
        {
            data[i] = 
            { 
                id: orders[i].getElementsByTagName(NameElementXML.Id)[0].innerHTML,
                name: orders[i].getElementsByTagName(NameElementXML.Name)[0].innerHTML,
                client: orders[i].getElementsByTagName(NameElementXML.Client)[0].innerHTML,
                price: orders[i].getElementsByTagName(NameElementXML.Price)[0].innerHTML
            }
        }

        setArrayOrder(data);
    }
}

export const  instanceRepository = () => new Repository()