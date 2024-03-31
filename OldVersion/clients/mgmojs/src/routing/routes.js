import { Observable } from "rxjs";
import { filter } from 'rxjs/operators';


export const routes =  {
    aricles:'articles',
    examples:'examples',
    root:'home'
}

const _routes = [
    {routeKey:routes.root, routeUrl:''},
    {routeKey:routes.examples, routeUrl:'examples'},
{routeKey:routes.aricles, routeUrl:'articles'}
];

export function getCurrentRoute() {
    const obs = new Observable(sub => {
        const currentR = _getCurrentRoute();
        sub.next({
            foundRoute:currentR.routeKey,
            route:location.hash
        })
        
        window.addEventListener('hashchange', (e) => {
           const currentR = _getCurrentRoute();
           sub.next({
               foundRoute:currentR.routeKey,
               route:location.hash
           })
        }, false);
    })
    return obs.pipe(filter(d => !!d.foundRoute));
}

function _getCurrentRoute() {
const foundRoute =  _routes.find(r => location.hash === `#${r.routeUrl}`);
return foundRoute || _routes[0];
}

