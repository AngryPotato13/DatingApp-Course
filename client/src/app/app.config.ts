import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideAnimations } from '@angular/platform-browser/animations';

import { routes } from './app.routes';
import { provideHttpClient } from '@angular/common/http';
import { provideToastr } from 'ngx-toastr';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideHttpClient(),      //allows the service to be available for injections
    provideAnimations(),
    provideToastr({positionClass: 'toast-bottom-right'})    //allows toastr to be used (pop ups)
  ]
};
