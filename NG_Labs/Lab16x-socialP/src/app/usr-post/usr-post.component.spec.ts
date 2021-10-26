import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsrPostComponent } from './usr-post.component';

describe('UsrPostComponent', () => {
  let component: UsrPostComponent;
  let fixture: ComponentFixture<UsrPostComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UsrPostComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UsrPostComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
