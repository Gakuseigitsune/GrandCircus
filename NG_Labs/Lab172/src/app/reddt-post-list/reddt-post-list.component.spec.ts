import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReddtPostListComponent } from './reddt-post-list.component';

describe('ReddtPostListComponent', () => {
  let component: ReddtPostListComponent;
  let fixture: ComponentFixture<ReddtPostListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReddtPostListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReddtPostListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
