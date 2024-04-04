import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { provideHttpClient } from '@angular/common/http';
import { provideEnvironmentNgxMask } from 'ngx-mask';

export const appConfig: ApplicationConfig = {
  providers: [
    provideEnvironmentNgxMask(),
    provideRouter(routes),
    provideHttpClient(),
    provideAnimationsAsync(),
  ]
};
