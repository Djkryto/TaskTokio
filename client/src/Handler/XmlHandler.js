import { parseXML } from "jquery"

export const initModelXML = (data) => {
   const xml = parseXML(
        "<Order>" +
        '<id>' + data.id + '</id>'+
        '<name>' + data.name + '</name>'+
        '<client>' + data.client + '</client>'+
        '<price>' + data.price + '</price>'
        + "</Order>"
        )

        return new XMLSerializer().serializeToString(xml);
}