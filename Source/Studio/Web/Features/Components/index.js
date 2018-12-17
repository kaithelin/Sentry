import { PLATFORM } from 'aurelia-pal';

export function configure(config) {
    config.globalResources(PLATFORM.moduleName('./app_header/app_header'));
}

