import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { UserService } from 'src/app/services/user.service';
import { SnackBarInfo } from 'src/app/services/snackbar-info.service';

@Component({
  selector: 'app-main-nav',
  templateUrl: './main-nav.component.html',
  styleUrls: ['./main-nav.component.scss']
})
export class MainNavComponent {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  isLoggedIn$ = this.userService.isLoggedIn$;

  constructor(private breakpointObserver: BreakpointObserver, private userService: UserService, private snackBarInfo: SnackBarInfo) {}

  logout() {
    this.userService.logout().subscribe(
      ok => {
        this.snackBarInfo.formOk('User logged out sucessfully.');
      },
      error => {
        this.snackBarInfo.formError(error);
      }
    );
  }

}
