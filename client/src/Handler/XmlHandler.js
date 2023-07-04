import { parseXML } from "jquery"

export const convertToJSON = () => {

}

export const initModelXML = (data) =>
    parseXML(
        "<Order>" +
        '<id>' + data.id + '</id>'+
        '<name>' + data.name + '</name>'+
        '<client>' + data.client + '</client>'+
        '<price>' + data.price + '</price>'
        + "</Order>"
        )
